﻿2024-04-15
assetName : ObjectPooling
version : 1.0.6

<업데이트> 
-SO를 저장하는 과정에서 작업이 날아가는 버그가 있었음. Pooling작업을 한 후 반드시 Generate Enum를 하도록!

<오브젝트 풀링 사용 방법>
1. Project 창에 우클릭을 누르고 Crogen/ObjectPooling/PoolingBase 경로로 PoolingBase를 생성한다.
2. PoolingBase를 클릭하고 Inspector 창에서 pairs에 요소를 추가한다.
3. 추가된 pairs 요소의 Prefab Type Name에 Pop으로 불러올 문자열 값을 입력한다.
4. Prefab에 풀링할 오브젝트 Prefab를 넣는다.
5. PoolCount에 초기에 생성할 PoolingObject의 개수를 지정한다. 
(Pop된 오브젝트의 개수가 PoolCount를 넘어서면 자동으로 오브젝트를 추가해 PoolingQueue에 넣어주니 걱정말자)

6. gameObject.Pop()과 transform.Pop()으로 게임오브젝트를 생성할 수 있다.
    -gameObject.Pop()으로 게임 오브젝트를 생성하면 생성된 오브젝트의 부모는 설정이 되지 않으며 해당 오브젝트를 기준으로 position, rotation를 설정할 수 있다.
    -transform.Pop()으로 게임 오브젝트를 생성하면 오브젝트의 부모는 해당 transform으로 설정이 된다. 
7. gameObject.Push()으로 해당 게임오브젝트를 비활성화 할 수 있다. 
