import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { Storage } from './storage';

const providers = [
    Storage    
];

@NgModule({
    imports: [CommonModule],
	providers: providers
})
export class UtilitiesModule { }
