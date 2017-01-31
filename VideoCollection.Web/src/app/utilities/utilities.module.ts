import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { Storage } from './storage';
import { OAuthHelper } from "./oauth-helper";

const providers = [
    Storage,
    OAuthHelper    
];

@NgModule({
    imports: [CommonModule],
	providers: providers
})
export class UtilitiesModule { }
