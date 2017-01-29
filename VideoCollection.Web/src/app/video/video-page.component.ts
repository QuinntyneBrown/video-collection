import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";
import { Location } from "@angular/common";
import { ActivatedRouteSnapshot } from "@angular/router";
import { ApiService } from "../shared";
import { Video } from "./video.model";

@Component({
    template: require("./video-page.component.html"),
    styles: [require("./video-page.component.scss")],
    selector: "video-page"
})
export class VideoPageComponent implements OnInit { 
    constructor(
        private _activatedRouteSnapshot: ActivatedRouteSnapshot,
        private _apiService: ApiService,
        private _location: Location) {
    }

    public onNext() {

    }

    public onPrevious() {

    }

    ngOnInit() {
        this._apiService
            .getVideos()
            .subscribe((videos: Array<Video>) => {
                this.videos = videos;
            });
    }

    public currentVideo: Video = <Video>{};

    public videos: Array<Video> = [];
}
