import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ApiService } from "./api.service";
import { AuthGuardService } from "./auth-guard.service";
import { SharedComponentsModule } from "./components";
import { LoginRedirectService } from './login-redirect.service';
import { CurrentUserService } from './current-user.service';

const providers = [
    ApiService,
    AuthGuardService,
    LoginRedirectService,
    CurrentUserService
];

@NgModule({
    imports: [CommonModule, SharedComponentsModule],
    exports: [
        SharedComponentsModule
    ],
	providers: providers
})
export class SharedModule { }
