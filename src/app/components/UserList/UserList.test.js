import React from 'react'
import { render, waitForElement, cleanup } from 'react-testing-library'
import SystemUnderTest from './index'

afterEach(cleanup)

const setup = ({ props, render }) => {

  const utils = render(<SystemUnderTest users={props} />);

  return {
    props,
    ...utils,
  }
}

const aUser = { email: 'm@a.com', password: 'pass@t' };

it('will correctly render user item', async () => {
  const { getByText } = setup({ render, props: [aUser] });

  await waitForElement(() => getByText(/m@a.com/i));
})

it('will correctly render multiple items', () => {
  const { container } = setup({ render, props: [aUser, aUser] });

  expect(container.querySelectorAll('li').length).toBe(2)
})