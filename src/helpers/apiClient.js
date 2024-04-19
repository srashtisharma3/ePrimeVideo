import axios from "axios"
import { API_ADDRESS } from "./constant"
import authUser from "./authUser"

const apiClient = axios.create({
    baseURL: API_ADDRESS,
    timeout: 500000,
    mode: 'cors',
    headers: {
        'Content-Type': 'application/json'
    }
});

apiClient.interceptors.request.use(
    (req) => {
        const user = authUser.Get();
        let token = user != null ? user.token : '';
        if (token) {
            req.headers.common.Authorization = `Bearer ${token}`;
        }
        return req;
    },
    (err) => {
        return Promise.reject(err);
    }
);

apiClient.interceptors.response.use(
    (res) => {
        return res;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default apiClient;