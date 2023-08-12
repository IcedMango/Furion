import { styled } from "styled-components";

const SiderSticky = styled.div<{ $top?: number }>`
  position: sticky;
  top: ${(props) => props.$top || 80}px;
  width: 200px;
  margin-right: 15px;
`;

export default SiderSticky;