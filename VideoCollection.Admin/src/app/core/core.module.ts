import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from "./auth.service";
import { AuthGuardService } from "./auth-guard.service";
import { CurrentUserService } from "./current-user.service";
import { LoginRedirectService } from "./login-redirect.service";

const declarables = [];
const providers = [
    AuthService,
    AuthGuardService,
    CurrentUserService,
    LoginRedirectService,    
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class CoreModule { }
