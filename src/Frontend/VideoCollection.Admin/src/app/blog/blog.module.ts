import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

const declarables = [];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class BlogModule { }
