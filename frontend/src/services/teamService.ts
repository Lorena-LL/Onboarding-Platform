import type { AxiosResponse } from "axios";
import axiosInstance from "../api/axios";
import type { TeamMemberDto } from "../models/team.types";

export const getLeads = async (userId: string): Promise<TeamMemberDto[]> => {
    const response: AxiosResponse<TeamMemberDto[]> = await axiosInstance.get<TeamMemberDto[]>(
        `/Team/${userId}/leads`
    );
    return response.data;
};