import React, { Component } from 'react'
import { Container, List } from 'semantic-ui-react'

import './DetailList.scss'

class DetailList extends Component {
    
    redner() {
        return (
            <div>
                <Container>
                    <List divided relaxed>
                        <List.Item>
                            <List.Content floated='right'>
                                Szczegóły
                </List.Content>
                            <List.Content>
                                Zadanie
                </List.Content>
                        </List.Item>
                    </List>
                </Container>

            </div>

        )
    }
}

export default DetailList;