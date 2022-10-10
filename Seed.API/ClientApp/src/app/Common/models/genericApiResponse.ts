export interface GenericApiResponse<T> {
    result: T,
    isError: boolean;
    message: string;
}
