  -- 后台产品类型菜单连接错误修改
  update t_menu
  set url='@web/@admin/config/configlist.aspx'
  
  where id=64