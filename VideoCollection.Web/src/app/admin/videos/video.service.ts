import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Video } from "./video.model";
import { Observable } from "rxjs";
import { OAuthHelper } from "../../utilities";

@Injectable()
export class VideoService {
    constructor(private _http: Http, private _oauthHelper: OAuthHelper) { }

    public add(entity: Video) {
        return this._http
            .post(`${this._baseUrl}/api/video/add`, entity)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get() {
        return this._http
            .get(`${this._baseUrl}/api/video/get`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public getById(options: { id: number }) {
        return this._http
            .get(`${this._baseUrl}/api/video/getById?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public remove(options: { id: number }) {
        return this._http
            .delete(`${this._baseUrl}/api/video/remove?id=${options.id}`)
            .map(data => data.json())
            .catch(err => {
                return Observable.of(false);
            });
    }

    public get _baseUrl() { return ""; }

}
