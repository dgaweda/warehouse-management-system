
export class AppConfig {
    private readonly APIUrl = 'http://localhost:44388/';
    
    getAPIUrl(): string {
        return this.APIUrl;
    }
}