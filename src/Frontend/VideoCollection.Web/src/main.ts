import { environment } from "./app/environment";
import { enableProdMode } from "@angular/core";
import { AppModule } from "./app/app.module";
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

if (environment.production) {
    enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
    .catch(err => console.error(err));