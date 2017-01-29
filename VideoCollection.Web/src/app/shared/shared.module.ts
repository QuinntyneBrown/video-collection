import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ApiService } from "./api.service";
import {
    AuthGuardService
} from "./guards";

const declarables = [];

const providers = [
    ApiService,
    AuthGuardService
];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class SharedModule { }
