import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { ApiService } from './api.service';

const providers = [ApiService];

@NgModule({
    imports: [CommonModule],
	providers: providers
})
export class SharedModule { }
