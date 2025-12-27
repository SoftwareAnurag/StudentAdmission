import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderTopComponent } from './header/header-top/header-top.component';
import { FooterComponent } from './footer/footer/footer.component';
@Component({
  selector: 'app-root',
  standalone: false,
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('student-admission-ui');
}
