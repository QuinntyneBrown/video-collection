import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { ApiService } from './api.service';
import { SeoService } from './seo.service';

const providers = [
    ApiService,
    SeoService
];

@NgModule({
    imports: [CommonModule],
	providers: providers
})
export class SharedModule { }
