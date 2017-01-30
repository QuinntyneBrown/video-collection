import { Component, Input, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { VideoService } from "./video.service";
import { Video } from "./video.model";

@Component({
    template: require("./video-edit-page.component.html"),
    styles: [require("./video-edit-page.component.scss")],
    selector: "video-edit-page"
})
export class VideoEditPageComponent { 
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _videoService: VideoService
    ) { }

    ngOnInit() {
        if (this._videoId) {
            this._videoService.getById({ id: this._videoId })
                .subscribe((response:any) => {
                    this.video = response.video;
                });
        }
    }

    public video: Video = <Video>{};

    private get _videoId() { return this._activatedRoute.snapshot.params["id"]; }


}
