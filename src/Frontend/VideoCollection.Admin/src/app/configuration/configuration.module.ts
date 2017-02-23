import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { ConfigurationService } from "./configuration.service";

const declarables = [];
const providers = [ConfigurationService];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class ConfigurationModule { }
