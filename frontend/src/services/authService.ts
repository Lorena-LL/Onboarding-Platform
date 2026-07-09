import type { AxiosResponse } from "axios";
import axiosInstance from "../api/axios";
import type { LoginRequestDto, AuthResponseDto } from "../models/auth.types";

export const login = async (
    payload: LoginRequestDto
): Promise<AuthResponseDto> => {
    const response: AxiosResponse<AuthResponseDto> = await axiosInstance.post<AuthResponseDto>(
      "/auth/login",
      payload
    );
    return response.data;
};