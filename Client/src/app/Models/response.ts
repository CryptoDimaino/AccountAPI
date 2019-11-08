export interface Response<T> {
  Message: string;
  DidError: boolean;
  Model: T;
}
