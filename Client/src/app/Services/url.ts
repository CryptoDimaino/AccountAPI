export class BaseUrl {
  baseUrl: string = "https://localhost:5001/api/v1/";
  // baseUrl: string = "http://10.250.103.190:5001/api/v1/";

  get url() {
    return this.baseUrl;
  }
}
