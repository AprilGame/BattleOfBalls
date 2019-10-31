# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *

class Food(KBEngine.Entity):
	def __init__(self):
		KBEngine.Entity.__init__(self)



	#实体销毁，出列表
	def onDestroy(self):
		KBEngine.globalData["Room_%i" % self.spaceID].onFoodDestroy(self.id)
	

	#返回实体类型
	def returnType(self):
		return 1


