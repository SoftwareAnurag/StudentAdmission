import { Component, OnInit, NgZone } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StepDataService } from '../../services/step-data.service';
import { CourseService } from '../../services/course.service';
import { Course } from '../../models/course.model';
import { PaymentService } from '../../services/payment.service';

declare var Razorpay: any;

@Component({
  selector: 'app-review-submit',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './review-submit.component.html',
  styleUrl: './review-submit.component.scss'
})
export class ReviewSubmitComponent implements OnInit {

  studentID: string | null = null;
  courses: Course[] = [];
  paymentStatus: string | null = null;
  paymentMessage: string = '';

  constructor(
    private stepDataService: StepDataService,
    private courseService: CourseService,
    private paymentService: PaymentService,
    private ngZone: NgZone   // ✅ inject NgZone
  ) { }

  ngOnInit() {
    this.studentID = this.stepDataService.getStudentID();
    
  }

  payNow() {
    // Reset before new attempt
    this.paymentStatus = null;
    this.paymentMessage = 'Processing payment...';

    this.paymentService.createOrder(500, 'INR', this.studentID!) 
      .subscribe((order: any) => {
        var options = {
          "key": "rzp_test_R62Zs3itZ0XiNy",
          "amount": order.amount,
          "currency": order.currency,
          "name": "Student Admission",
          "description": "Admission Payment",
          "order_id": order.id,
          "handler": (response: any) => {
            // ✅ Run inside Angular zone
            this.ngZone.run(() => {
              this.paymentService.verifyPayment({
                orderId: response.razorpay_order_id,
                paymentId: response.razorpay_payment_id,
                signature: response.razorpay_signature,
                studentId:  this.studentID!,
                Amount : order.amount,
                Status : "Success"
              }).subscribe((res: any) => {
                this.paymentStatus = 'success';
                this.paymentMessage = 'Payment successful and saved in DB!';
              });
            });
          }
        };

        var rzp1 = new Razorpay(options);

        // ❌ Payment Failure Handling
        rzp1.on('payment.failed', (response: any) => {
          this.ngZone.run(() => {   // ✅ ensure UI update
            this.paymentStatus = 'failed';
            let errorMessage = 'Payment failed. Please try again later.';
            if (response && response.error) {
              errorMessage = response.error.description || response.error.reason || errorMessage;
            }
            this.paymentMessage = errorMessage;
          });

          try {
            rzp1.close();
          } catch (e) {
            console.warn("Popup auto-close fallback triggered.");
            document.querySelector('.razorpay-container')?.remove();
          }
        });

        rzp1.open();
      });
  }
}
