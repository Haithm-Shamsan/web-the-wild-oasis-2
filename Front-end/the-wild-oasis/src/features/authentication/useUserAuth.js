import {  useQuery } from "@tanstack/react-query";
import { getCurrentClient } from "../../services/apiAuth";








export function useUserAuth() {
    const { isLoading, data: user, error } = useQuery({
        queryFn: getCurrentClient,
        queryKey: ['user'],
    });

    if (error) {
        console.error('Error fetching user:', error);
    }

    return { 
        isLoading, 
        isAuthenticated: user?.role === 'authenticated',
        error ,user
    };
}
 