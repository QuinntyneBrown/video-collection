import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./jw-player-controls.component.html"),
    styles: [require("./jw-player-controls.component.scss")],
    selector: "jw-player-controls",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class JwPlayerControlsComponent implements OnInit { 
    ngOnInit() {

    }
}
