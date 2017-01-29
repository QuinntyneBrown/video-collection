import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ApiService } from "./api.service";
import { AuthGuardService } from "./auth-guard.service";
import { SharedComponentsModule } from "./components";

const providers = [
    ApiService,
    AuthGuardService
];

@NgModule({
    imports: [CommonModule, SharedComponentsModule],
    exports: [
        SharedComponentsModule
    ],
	providers: providers
})
export class SharedModule { }
