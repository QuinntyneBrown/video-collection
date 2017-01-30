import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";   
import { VideoService } from "./video.service";

@Component({
    template: require("./video-list-page.component.html"),
    styles: [require("./video-list-page.component.scss")],
    selector: "video-list-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class VideoListPageComponent implements OnInit {
    constructor(
        private _videoService: VideoService
    ) {

    }

    ngOnInit() {

    }
    
}
