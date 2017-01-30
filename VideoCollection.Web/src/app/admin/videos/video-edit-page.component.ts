import { Component, Input, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { VideoService } from "./video.service";

@Component({
    template: require("./video-edit-page.component.html"),
    styles: [require("./video-edit-page.component.scss")],
    selector: "video-edit-page"
})
export class VideoEditPageComponent { 
    constructor(
        private _videoService: VideoService
    ) { }

    ngOnInit() { }

}
