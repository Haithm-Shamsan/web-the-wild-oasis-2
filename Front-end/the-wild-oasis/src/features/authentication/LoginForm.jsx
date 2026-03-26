import { useState } from "react";
import Button from "../../ui/Button";
import Form from "../../ui/Form";
import FormRow from "../../ui/FormRow";
import Input from "../../ui/Input";


import styled from "styled-components";
import { useLogin } from "./useLogin";
import Spinner from "../../ui/Spinner";

const StyledForm = styled.form`
  display: flex;
  background-color: white;
  padding:45px;
  flex-direction: column;
  width: 95%; /* Ensure form takes full width */
`;

const StyledFormRow = styled.div`
  display: flex;
  flex-direction: column;
  margin-bottom: 1rem; /* Add spacing between form rows */
  
  label {
    margin-bottom: 0.5rem;
    font-weight: bold;
    margin-bottom:10px;
    display: block; /* Make sure label is block to take full width */
  }

  input {
    width: 100%; /* Input takes full width */
  
    border: 2px solid #ccc;
    border-radius: 4px;
    padding:10px;
    margin:5px 0px 10px 0px;

  }
`;


function LoginForm() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const { login, isLoading } = useLogin();

  function handleSubmit(e) {
    e.preventDefault();

    if (!email || !password) return;
   
    login({ email, password });
  }

  if(isLoading) return <Spinner/>
  return (
    <StyledForm onSubmit={handleSubmit}>
      <StyledFormRow>
        <label htmlFor="email">Email address</label>
        <input
          type="email"
          id="email"
          autoComplete="username"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          disabled={isLoading}
        />
      </StyledFormRow>

      <StyledFormRow>
        <label htmlFor="password">Password</label>
        <input
          type="password"
          id="password"
          autoComplete="current-password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
            disabled={isLoading}
        />
      </StyledFormRow>

      <StyledFormRow>
        <Button  type="submit">Login</Button>
      </StyledFormRow>
    </StyledForm>
  );
}
export default LoginForm;
