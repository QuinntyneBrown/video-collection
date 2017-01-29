import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { LoginRedirectService } from './login-redirect.service';
import { CurrentUserService } from './current-user.service';


const declarables = [];

const providers = [
    LoginRedirectService,
    CurrentUserService
];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class LoginModule { }
