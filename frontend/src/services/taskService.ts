import type { AxiosResponse } from "axios";
import axiosInstance from "../api/axios";
import type { AssignedOnboardingTaskDto } from "../models/task.types";

export const getActiveAssignedTasks = async (userId: string): Promise<AssignedOnboardingTaskDto[]> => {
    const response: AxiosResponse<AssignedOnboardingTaskDto[]> = await axiosInstance.get<AssignedOnboardingTaskDto[]>(
        `/AssignedOnboardingTask/user/${userId}/active`
    );
    return response.data;
};