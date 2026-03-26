import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { logout as logoutApi } from "../../services/apiAuth";

export function useLogout() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();

  const { mutate: logout, isLoading } = useMutation({
    mutationFn: logoutApi,
    onSuccess: () => {
      // Clear all cached queries (or you can clear specific queries)
      queryClient.clear();

      // Redirect to login page after logout
      navigate("/login", { replace: true });
    },
    onError: (error) => {
      console.error("Logout failed:", error);
      // Optionally handle the error (e.g., show notification)
    },
  });

  return { isLoading, logout };
}
