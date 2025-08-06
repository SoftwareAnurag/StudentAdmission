
import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { appConfig } from './app/app.config';
import { App } from './app/app';

bootstrapApplication(App, appConfig)
  .catch((err) => console.error(err));

  bootstrapApplication(App, {
  providers: [
    provideHttpClient(),  // Use this instead of HttpClientModule
    ...appConfig.providers
  ]
}).catch(err => console.error(err));