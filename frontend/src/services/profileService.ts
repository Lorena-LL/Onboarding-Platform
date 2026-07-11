import type { AxiosResponse } from "axios";
import axiosInstance from "../api/axios";
import type { ProfileAllInfoResponseDto } from "../models/profile.types";

export const getProfileById = async (
    id: string
): Promise<ProfileAllInfoResponseDto> => {
    const response: AxiosResponse<ProfileAllInfoResponseDto> = await axiosInstance.get<ProfileAllInfoResponseDto>(
        `/profile/${id}`
    );
    return response.data;
};