import styled from "styled-components";
import HeaderMenu from "./HeaderMenu";
import UserAvatar from "../features/authentication/UserAvatar";

const StyledHeader = styled.header`
  background-color: var(--color-grey-0);
  padding: 1.2rem 4.8rem;
  display: flex;
  flex-direction: row-reverse;
  align-items: center; /* Ensure items are centered vertically */
  justify-content: space-between; /* Space out items evenly */
  border-bottom: 1px solid var(--color-grey-100);
`;

function Header() {
  return (
    <StyledHeader>
      <HeaderMenu />
      <UserAvatar />
    </StyledHeader>
  );
}

export default Header;
