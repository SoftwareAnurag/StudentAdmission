
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})


export class PaymentService {

    private baseUrl = 'http://localhost:44302/api/payment';

    constructor(private http: HttpClient) {}

    createOrder(amount: number, currency: string, studentId: string) {
        return this.http.post(`${this.baseUrl}/create-order`, {
            amount,
            currency,
            studentId
        });
    }

    verifyPayment(paymentResponse: any) {
        return this.http.post(`${this.baseUrl}/verify`, paymentResponse);
    }

}