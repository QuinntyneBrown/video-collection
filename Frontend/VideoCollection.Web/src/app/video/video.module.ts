import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";

import { JwPlayerComponent } from './jw-player-handler.component';
import { JwPlayerContainerComponent } from './jw-player-container.component';
import { JwPlayerControlsComponent } from './jw-player-controls.component';

const declarables = [JwPlayerComponent];

@NgModule({
    imports: [CommonModule],
    exports: [declarables],
    declarations: [declarables],
	providers: providers
})
export class VideoModule { }
