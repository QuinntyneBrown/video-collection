import { Injectable } from "@angular/core";
import { Headers } from "@angular/http";
import { Storage } from "./storage";

@Injectable()
export class OAuthHelper {
    constructor(private _storage: Storage) { }
    
    public getToken() { return this._storage.get({ name: "accessToken" }); }

    public getOAuthHeaders() {
        let headers = new Headers();
        headers.append('Authorization', `Bearer ${this.getToken()}`);
        return headers;
    }
}