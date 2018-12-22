import React from 'react'
import { Container, Dropdown, Header, List, Button, Divider } from 'semantic-ui-react'

import './Grade.scss';

const options = [
    { key: 1, text: '0', value: 0 },
    { key: 2, text: '1', value: 1 },
    { key: 3, text: '2', value: 2 },
    { key: 3, text: '3', value: 3 },
    { key: 3, text: '4', value: 4 },
    { key: 3, text: '5', value: 5 },
    { key: 3, text: '6', value: 6 },
    { key: 3, text: '7', value: 7 },
    { key: 3, text: '8', value: 8 },
    { key: 3, text: '9', value: 9 },
    { key: 3, text: '10', value: 10 }
]

const Grade = () => (
    <div className="gradecontainer">
        <Container>
            <Header as='h3' dividing>Oceń studenta</Header>
            <div>
                <List divided verticalAlign='middle'>
                    <List.Item>
                        <List.Content floated='right'>
                            <Dropdown placeholder='0' direction='right' compact selection options={options}></Dropdown>
                        </List.Content>
                        <List.Content>
                            Waruek oceny 1.
                        </List.Content>
                    </List.Item>

                    <List.Item>
                        <List.Content floated='right'>
                            <Dropdown placeholder='0' direction='right' compact selection options={options}></Dropdown>
                        </List.Content>
                        <List.Content>
                            Waruek oceny 2.
                        </List.Content>
                    </List.Item>

                                        <List.Item>
                        <List.Content floated='right'>
                            <Dropdown placeholder='0' direction='right' compact selection options={options}></Dropdown>
                        </List.Content>
                        <List.Content >
                            Waruek oceny 3.
                        </List.Content>
                    </List.Item>

                                        <List.Item>
                        <List.Content floated='right'>
                            <Dropdown placeholder='0' direction='right' compact selection options={options}></Dropdown>
                        </List.Content>
                        <List.Content >
                            Waruek oceny 4.
                        </List.Content>
                    </List.Item>
                </List>
            </div>

            <Divider />

            <List>
                <List.Item>
                    <List.Content floated='right'>
                        <Button >Wyślij</Button>
                    </List.Content>
                    <List.Content>
                        <Header as='h4'>Średnia ocena:</Header>
                    </List.Content>
                </List.Item>
            </List>
        </Container>
    </div>
)

export default Grade