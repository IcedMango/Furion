import { Dropdown, DropdownProps } from "antd";
import React from "react";
import { styled } from "styled-components";
import IconFont from "../../../components/iconfont";

const Container = styled.div``;

const Icon = styled(IconFont)`
  font-size: 22px;
  color: #8c8c8c;
  cursor: pointer;
  display: block;

  &:hover {
    color: #1677ff;
  }
`;

const ContentMenu: React.FC<DropdownProps> = (props) => {
  return (
    <Dropdown placement="bottomLeft" {...props}>
      <Container>
        <Icon type="icon-more-menu" />
      </Container>
    </Dropdown>
  );
};

export default ContentMenu;