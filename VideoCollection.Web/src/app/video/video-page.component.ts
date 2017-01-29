import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./video-page.component.html"),
    styles: [require("./video-page.component.scss")],
    selector: "video-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class VideoPageComponent implements OnInit { 
    ngOnInit() {

    }
}
