/*
    THOSE ARE GLOBAL SETTINGS FOR THE WHOLE APPLICATION
*/
import { Injectable } from "@angular/core";

@Injectable()
export class AppConfig {
    private _config: { [key: string]: string };

    constructor() {
        this._config = { 
            PathAPI: 'http://localhost:54789/api/'
            
        }
    }

    getConfig(): { [key: string]: string } {
        return this._config;
    }

    getConfigByKey(key: string): string {
        return this._config[key];
    }
}