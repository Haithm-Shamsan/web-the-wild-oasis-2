import styled from "styled-components";
import { useUserAuth } from "../features/authentication/useUserAuth";
import Spinner from "./Spinner";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";

const FullPage = styled.div`
  height: 100vh;
  background-color: var(--color-grey-50);
  display: flex;
  align-items: center;
  justify-content: center;
`;

function ProtectedRout({ children }) {
  const navigate = useNavigate();
  const { isLoading, isAuthenticated } = useUserAuth();
  useEffect(() => {
    if (!isAuthenticated && !isLoading) {
      navigate("/login");
    }
  }, [isAuthenticated, isLoading, navigate]);

  // Show spinner while loading
  if (isLoading) {
    return (
      <FullPage>
        <Spinner />
      </FullPage>
    );
  }


  // Return children if authenticated
  if (isAuthenticated) return children;

  return null; // Optionally, return null or a fallback if not authenticated.
}

export default ProtectedRout;
