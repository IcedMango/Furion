import { Space } from "antd";
import React, { useState } from "react";
import { css, styled } from "styled-components";
import Flexbox from "./flexbox";

const Container = styled(Flexbox)`
  align-items: flex-start;
`;

const Title = styled.div`
  font-size: 13px;
  background-color: #f0f0f0;
  display: inline-block;
  margin-right: 15px;
  padding: 0 10px;
  border-radius: 5px;
  color: #595959;
  user-select: none;
  font-weight: 600;
  white-space: nowrap;
  margin-top: 2px;
`;

const Main = styled.div`
  flex: 1;
`;

const Item = styled.div<{ $active?: boolean }>`
  cursor: pointer;
  padding: 1px 8px;
  border-radius: 5px;
  user-select: none;
  font-weight: 500;
  white-space: nowrap;

  &:hover {
    color: #1677ff;
  }

  ${(props) =>
    props.$active === true &&
    css`
      background-color: #1677ff;
      color: #ffffff;
      font-weight: 600;

      &:hover {
        color: #ffffff;
      }
    `}
`;

interface CategoryItemProps {
  key: string;
  label?: React.ReactNode;
}

interface CategoryListProps {
  title: React.ReactNode;
  items?: CategoryItemProps[];
  onChange?: (key: string) => void;
  defaultKey?: string;
}

const CategoryList: React.FC<CategoryListProps> = ({
  title,
  items,
  onChange,
  defaultKey,
}) => {
  const [selectKey, setSelectKey] = useState(
    defaultKey || (items && items.length > 0 ? items[0].key : undefined)
  );

  return (
    <Container>
      <Title>{title}</Title>
      <Main>
        <Space size={[15, 10]} wrap>
          {items &&
            items.map((item) => (
              <Item
                key={item.key}
                onClick={() => {
                  setSelectKey(item.key);
                  onChange && onChange(item.key);
                }}
                $active={item.key === selectKey}
              >
                {item.label}
              </Item>
            ))}
        </Space>
      </Main>
    </Container>
  );
};

export default CategoryList;