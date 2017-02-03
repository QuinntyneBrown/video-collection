import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { ConfigurationComponent } from './configuration.component';

const declarables = [ConfigurationComponent];
const providers = [];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class ConfigurationModule { }
