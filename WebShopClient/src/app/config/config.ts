import { Injectable } from '@angular/core';

@Injectable()

export class AppConfig {



    private _config: { [key: string]: string };

    constructor() {

        this._config = {

            PathAPI: 'https://localhost:44387/api'

        };

    }

    get setting(): { [key: string]: string } {

        return this._config;

    }

    get(key: any) {

        return this._config[key];

    }

};