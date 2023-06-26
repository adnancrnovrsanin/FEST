import axios, { AxiosError, AxiosResponse } from 'axios';
import { API_URL } from '../common/constants';
import { store } from '../stores/store';
import { toast } from 'react-toastify';
import { LoginRequestDto, LoginResponseDto, RegisterRequestDto, RegisterResponseDto } from '../common/interfaces/AuthInterfaces';
import { Festival, FestivalDto } from '../common/interfaces/FestivalInterfaces';
import { User } from '../common/interfaces/UserInterfaces';

axios.defaults.baseURL = API_URL;

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

axios.interceptors.request.use(config => {
    const token = store.commonStore.token;
    if (token && config.headers) config.headers.Authorization = `Bearer ${token}`;
    return config;
});

axios.interceptors.response.use(async response => {
    return response;
}, (error: AxiosError) => {
    const { data, status } = error.response as AxiosResponse;

    if (status) {
        switch (status) {
            case 400:
                toast.error(data)
                break;
            case 401:
                toast.error('Error code 401: Unauthorized')
                break;
            case 403:
                toast.error('Error code 403: Forbidden')
                break;
            case 404:
                toast.error('Error code 404: Not found')
                break;
            case 500:
                store.commonStore.setServerError(data);
                // router navigates to /server-error
                break;
        }
    }

    return Promise.reject(error);
});

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: object) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: object) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody)
}

const AccountRequests = {
    current: () => requests.get<User>('/account'),
    login: (user: LoginRequestDto) => requests.post<LoginResponseDto>('/account/login', user),
    register: (user: RegisterRequestDto) => requests.post<RegisterResponseDto>('/account/register', user),
}

const FestivalRequests = {
    all: () => requests.get<FestivalDto[]>('/festival'),
    details: (id: string) => requests.get<FestivalDto>(`/festival/${id}`),
    create: (festival: Festival) => requests.post<FestivalDto>('/festival', festival),
    update: (festival: Festival) => requests.put<FestivalDto>(`/festival/${festival.id}`, festival),
    delete: (id: string) => requests.del<void>(`/festival/${id}`),
}

const agent = {
    AccountRequests,
    FestivalRequests,
}

export default agent;