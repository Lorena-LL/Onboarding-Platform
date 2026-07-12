import type { AxiosResponse } from "axios";
import axiosInstance from "../api/axios";
import type { AssignedOnboardingTaskDto } from "../models/task.types";

export const getActiveAssignedTasks = async (userId: string): Promise<AssignedOnboardingTaskDto[]> => {
    const response: AxiosResponse<AssignedOnboardingTaskDto[]> = await axiosInstance.get<AssignedOnboardingTaskDto[]>(
        `/AssignedOnboardingTask/user/${userId}/active`
    );
    return response.data;
};

export const getCompletedAssignedTasks = async (userId: string): Promise<AssignedOnboardingTaskDto[]> => {
    const response: AxiosResponse<AssignedOnboardingTaskDto[]> = await axiosInstance.get<AssignedOnboardingTaskDto[]>(
        `/AssignedOnboardingTask/user/${userId}/completed`
    );
    return response.data;
};

export const getTaskById = async (id: string): Promise<AssignedOnboardingTaskDto> => {
    const response: AxiosResponse<AssignedOnboardingTaskDto> = await axiosInstance.get<AssignedOnboardingTaskDto>(
        `/AssignedOnboardingTask/${id}`
    );
    return response.data;
};

export const completeTask = async (assignedTaskId: string, userId: string): Promise<void> => {
    await axiosInstance.patch(`/AssignedOnboardingTask/${assignedTaskId}/complete/user/${userId}`);
};