import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { AdminComponent } from './admin.component';

const declarables = [AdminComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class AdminModule { }
