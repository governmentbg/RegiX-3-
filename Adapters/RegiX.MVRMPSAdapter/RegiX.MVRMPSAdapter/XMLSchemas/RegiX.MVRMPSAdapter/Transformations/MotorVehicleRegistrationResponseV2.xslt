<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MVR/MPS/GetMotorVehicleRegistrationInfoV2Response" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<br/>
					<h1 align="center">
						<span>
							<xsl:text>Разширена справка за МПС по регистрационен номер</xsl:text>
						</span>
					</h1>
					<br/>
					<xsl:for-each select="n1:GetMotorVehicleRegistrationInfoV2Response">
						<xsl:for-each select="n1:Response">
							<xsl:for-each select="n1:Results">
								<xsl:for-each select="n1:Result">
									<xsl:for-each select="n1:VehicleData">
										<h2>
											<span>
												<xsl:text>Данни за автомобил</xsl:text>
											</span>
										</h2>
										<xsl:for-each select="n1:RegistrationNumber">
											<span style="font-weight:bold; ">
												<xsl:text>(А) Регистрационен номер: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:FirstRegistrationDate">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(B) Дата на първа регистрация:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:VIN">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(E) VIN: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:EngineNumber">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(P5) Номер на двигателя: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:VehicleType">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>Вид на ПС:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:Model">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(D.1) Марка и модел:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:TypeApprovalNumber">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(K) Номер&#160; на тип на одобрение: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:ApprovalType">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(D.2) Тип на одобрение (Вариант/Версия): </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:TradeDescription">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(D.3) Търговско наименование: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:Color">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(R) Цвят: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:Category">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(J) Категория: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:OffRoadSymbols">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>Повишена проходимост: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:MassG">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(G) Маса на превозното средство: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:MassF1">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(F.1) Техническа допустима максимална маса: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:Capacity">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(P1) Обем на двигателя: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:MaxPower">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(P2) Максимална мощност: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:Fuel">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(P3) Вид гориво: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<xsl:for-each select="n1:EnvironmentalCategory">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>(V.9) Екологична категория: </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
										<br/>
										<xsl:for-each select="n1:VehicleDocument">
											<h3>
												<span>
													<xsl:text>Данни за документ за регистрация</xsl:text>
												</span>
											</h3>
											<xsl:for-each select="n1:VehDocumentNumber">
												<span style="font-weight:bold; ">
													<xsl:text>Номер на документ за регистрация: </xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
											<br/>
											<xsl:for-each select="n1:VehDocumentDate">
												<span style="font-weight:bold; ">
													<xsl:text>Дата на издаване: </xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
									<br/>
									<xsl:for-each select="n1:OwnersData">
										<xsl:for-each select="n1:Owner">
											<br/>
											<h2>
												<span>
													<xsl:text>Данни за собственик</xsl:text>
												</span>
											</h2>
											<xsl:for-each select="n1:BulgarianCitizen">
												<br/>
												<xsl:if test="string-length( . ) &gt;0">
													<span style="text-decoration:underline; ">
														<xsl:text>Български гражданин</xsl:text>
													</span>
												</xsl:if>
												<br/>
												<br/>
												<xsl:for-each select="n1:PIN">
													<span style="font-weight:bold; ">
														<xsl:text>Единен граждански номер (ЕГН): </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:Names">
													<xsl:for-each select="n1:First">
														<br/>
														<span style="font-weight:bold; ">
															<xsl:text>Собствено име: </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
													<xsl:for-each select="n1:Surname">
														<br/>
														<span style="font-weight:bold; ">
															<xsl:text>Бащино име: </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
													<xsl:for-each select="n1:Family">
														<br/>
														<span style="font-weight:bold; ">
															<xsl:text>Фамилно име: </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
												</xsl:for-each>
											</xsl:for-each>
											<xsl:for-each select="n1:ForeignCitizen">
												<br/>
												<xsl:if test="string-length( . ) &gt; 0">
													<span style="text-decoration:underline; ">
														<xsl:text>Чужденец</xsl:text>
													</span>
												</xsl:if>
												<br/>
												<br/>
												<xsl:for-each select="n1:PIN">
													<span style="font-weight:bold; ">
														<xsl:text>Единен граждански номер (ЕГН): </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:PN">
													<br/>
													<span style="font-weight:bold; ">
														<xsl:text>Личен номер на чужденец (ЛНЧ): </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:NamesCyrillic">
													<br/>
													<span style="font-weight:bold; ">
														<xsl:text>Имена на лицето на кирилица: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:NamesLatin">
													<br/>
													<span style="font-weight:bold; ">
														<xsl:text>Имена на лицето на латиница:</xsl:text>
													</span>
													<span>
														<xsl:text>&#160;</xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:Nationality">
													<br/>
													<span style="font-weight:bold; ">
														<xsl:text>Националност:</xsl:text>
													</span>
													<span>
														<xsl:text>&#160;</xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
											</xsl:for-each>
											<xsl:for-each select="n1:Company">
												<br/>
												<xsl:if test="string-length( . ) &gt;0">
													<span style="text-decoration:underline; ">
														<xsl:text>Фирма</xsl:text>
													</span>
												</xsl:if>
												<br/>
												<br/>
												<xsl:for-each select="n1:ID">
													<span style="font-weight:bold; ">
														<xsl:text>Идентификатор: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<br/>
												<xsl:for-each select="n1:Name">
													<span style="font-weight:bold; ">
														<xsl:text>Наименование: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<br/>
												<xsl:for-each select="n1:NameLatin">
													<span style="font-weight:bold; ">
														<xsl:text>Наименование на латиница: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
									<xsl:for-each select="n1:UsersData">
										<xsl:for-each select="n1:User">
											<br/>
											<h2>
												<span>
													<xsl:text>Данни за потребител</xsl:text>
												</span>
											</h2>
											<xsl:for-each select="n1:BulgarianCitizen">
												<br/>
												<xsl:if test="string-length( . ) &gt;0">
													<span style="text-decoration:underline; ">
														<xsl:text>Български гражданин</xsl:text>
													</span>
												</xsl:if>
												<br/>
												<br/>
												<xsl:for-each select="n1:PIN">
													<span style="font-weight:bold; ">
														<xsl:text>Едине граждански номер (ЕГН): </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:Names">
													<xsl:for-each select="n1:First">
														<br/>
														<span style="font-weight:bold; ">
															<xsl:text>Собствено име: </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
													<xsl:for-each select="n1:Surname">
														<br/>
														<span style="font-weight:bold; ">
															<xsl:text>Бащино име: </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
													<xsl:for-each select="n1:Family">
														<br/>
														<span style="font-weight:bold; ">
															<xsl:text>Фамилно име: </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
												</xsl:for-each>
												<br/>
											</xsl:for-each>
											<br/>
											<br/>
											<xsl:for-each select="n1:ForeignCitizen">
												<br/>
												<xsl:if test="string-length( . ) &gt; 0">
													<span style="text-decoration:underline; ">
														<xsl:text>Чужденец</xsl:text>
													</span>
												</xsl:if>
												<br/>
												<xsl:for-each select="n1:PIN">
													<span style="font-weight:bold; ">
														<xsl:text>Единен граждански номер (ЕГН): </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:PN">
													<br/>
													<span style="font-weight:bold; ">
														<xsl:text>Личен номер на чужденец (ЛНЧ): </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:NamesCyrillic">
													<br/>
													<span style="font-weight:bold; ">
														<xsl:text>Имена на лицето на кирилица: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:NamesLatin">
													<br/>
													<span style="font-weight:bold; ">
														<xsl:text>Имена на лицето на латиница:</xsl:text>
													</span>
													<span>
														<xsl:text>&#160;</xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:Nationality">
													<br/>
													<span style="font-weight:bold; ">
														<xsl:text>Националност:</xsl:text>
													</span>
													<span>
														<xsl:text>&#160;</xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
											</xsl:for-each>
											<xsl:for-each select="n1:Company">
												<br/>
												<xsl:if test="string-length( . ) &gt;0">
													<span style="text-decoration:underline; ">
														<xsl:text>Фирма</xsl:text>
													</span>
												</xsl:if>
												<br/>
												<br/>
												<xsl:for-each select="n1:ID">
													<span style="font-weight:bold; ">
														<xsl:text>Идентификатор: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<br/>
												<xsl:for-each select="n1:Name">
													<span style="font-weight:bold; ">
														<xsl:text>Наименование: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<br/>
												<xsl:for-each select="n1:NameLatin">
													<span style="font-weight:bold; ">
														<xsl:text>Наименование на латиница: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
							<br/>
							<hr/>
							<br/>
							<table border="1">
								<tbody>
									<tr>
										<th align="left">
											<span>
												<xsl:text>Код на изпълнение на опрацията: </xsl:text>
											</span>
											<br/>
											<span>
												<xsl:text>0000-успешна операция;</xsl:text>
											</span>
											<br/>
											<span>
												<xsl:text>0100-няма данни отговарящи на условието.</xsl:text>
											</span>
											<br/>
											<span>
												<xsl:text>Други значения означават възникване на грешка - подлежат на допълнително уточняване</xsl:text>
											</span>
										</th>
										<xsl:for-each select="n1:ReturnInformation">
											<td>
												<xsl:for-each select="n1:ReturnCode">
													<xsl:apply-templates/>
												</xsl:for-each>
											</td>
										</xsl:for-each>
									</tr>
									<tr>
										<th align="left">
											<span>
												<xsl:text>Описание на грешката (ако е възникнала такава)</xsl:text>
											</span>
										</th>
										<xsl:for-each select="n1:ReturnInformation">
											<td>
												<xsl:for-each select="n1:Info">
													<xsl:apply-templates/>
												</xsl:for-each>
											</td>
										</xsl:for-each>
									</tr>
								</tbody>
							</table>
						</xsl:for-each>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
