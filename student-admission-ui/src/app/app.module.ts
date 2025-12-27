
import { NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { App } from './app';
import { HeaderTopComponent } from './header/header-top/header-top.component';
import { FooterComponent } from './footer/footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { StudentAdmissionModule } from './features/student-admission/student-admission-module';


@NgModule({
  declarations: [
    App,
    HeaderTopComponent,
    FooterComponent,
  ],
  imports: [ 
   BrowserModule,   
   HttpClientModule,
   StudentAdmissionModule,
   AppRoutingModule
  ],
  providers: [
   
  ],
  bootstrap: [App]
})
export class AppModule {

}