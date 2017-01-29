import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ApiService } from "./api.service";
import {
    AuthGuardService
} from "./guards";

import {
    AppHeaderComponent,
    JwPlayerHandlerComponent
} from "./components";

const declarables = [
    AppHeaderComponent,
    JwPlayerHandlerComponent
];

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
