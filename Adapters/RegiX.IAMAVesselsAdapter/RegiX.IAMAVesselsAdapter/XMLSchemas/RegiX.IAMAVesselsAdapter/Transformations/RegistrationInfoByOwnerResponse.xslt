<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/IAMA" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/IAMA/RegistrationInfoByOwnerResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<h3 align="center">
						<span>
							<xsl:text>Справка за регистрация на кораб</xsl:text>
						</span>
					</h3>
					<span>
						<xsl:text>I. Данни за регистрацията на кораба</xsl:text>
					</span>
					<br/>
					<br/>
					<xsl:for-each select="n1:RegistrationInfoByOwnerResponse">
						<p>
							<xsl:for-each select="n1:VesselInfo">
								<xsl:for-each select="common:RegistrationData">
									<br/>
									<ul start="0">
										<li>
											<span>
												<xsl:text>Име на кирилица: </xsl:text>
											</span>
											<xsl:for-each select="common:ShipName">
												<xsl:apply-templates/>
											</xsl:for-each>
										</li>
										<li>
											<span>
												<xsl:text>Име на латиница: </xsl:text>
											</span>
											<xsl:for-each select="common:ShipNameLatin">
												<xsl:apply-templates/>
											</xsl:for-each>
										</li>
										<li>
											<span>
												<xsl:text>Пристанище на регистрация: </xsl:text>
											</span>
											<xsl:for-each select="common:RegistrationPort">
												<xsl:apply-templates/>
											</xsl:for-each>
										</li>
										<li>
											<span>
												<xsl:text>Номер на регистрация: </xsl:text>
											</span>
											<xsl:for-each select="common:RegistrationNumber">
												<xsl:apply-templates/>
											</xsl:for-each>
										</li>
										<li>
											<span>
												<xsl:text>Том: </xsl:text>
											</span>
											<xsl:for-each select="common:Tom">
												<xsl:apply-templates/>
											</xsl:for-each>
										</li>
										<li>
											<span>
												<xsl:text>Страница: </xsl:text>
											</span>
											<xsl:for-each select="common:Page">
												<xsl:apply-templates/>
											</xsl:for-each>
										</li>
										<li>
											<span>
												<xsl:text>Вид на кораба: </xsl:text>
											</span>
											<xsl:for-each select="common:Type">
												<xsl:apply-templates/>
											</xsl:for-each>
										</li>
										<li>
											<span>
												<xsl:text>Статус: </xsl:text>
											</span>
											<xsl:for-each select="common:Status">
												<xsl:choose>
													<xsl:when test="text() = &apos;Active&apos;">
														<span>
															<xsl:text>Действащ</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="text() = &apos;Inactive&apos;">
														<span>
															<xsl:text>Отписан</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="text() = &apos;Erased&apos;">
														<span>
															<xsl:text>Заличен</xsl:text>
														</span>
													</xsl:when>
												</xsl:choose>
											</xsl:for-each>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<br/>
										</li>
									</ul>
									<br/>
								</xsl:for-each>
							</xsl:for-each>
						</p>
						<span>
							<xsl:text>II. Данни за собствениците на кораба</xsl:text>
						</span>
						<br/>
						<xsl:for-each select="n1:VesselInfo">
							<xsl:for-each select="common:Owners">
								<br/>
								<xsl:for-each select="common:Owner">
									<ul start="0">
										<li>
											<xsl:choose>
												<xsl:when test="common:IsCompany=&quot;true&quot;">
													<xsl:for-each select="common:Company">
														<xsl:for-each select="common:CompanyName">
															<span>
																<xsl:text>Фирма: </xsl:text>
															</span>
															<xsl:apply-templates/>
														</xsl:for-each>
													</xsl:for-each>
													<xsl:for-each select="common:Company">
														<xsl:for-each select="common:EIK">
															<span>
																<xsl:text>, ЕИК: </xsl:text>
															</span>
															<xsl:apply-templates/>
														</xsl:for-each>
													</xsl:for-each>
												</xsl:when>
												<xsl:when test="common:IsCompany=&quot;false&quot;">
													<xsl:for-each select="common:Person">
														<xsl:for-each select="common:Names">
															<xsl:for-each select="common:FirstName">
																<xsl:apply-templates/>
															</xsl:for-each>
														</xsl:for-each>
													</xsl:for-each>
													<xsl:for-each select="common:Person">
														<xsl:for-each select="common:Names">
															<xsl:for-each select="common:SurName">
																<span>
																	<xsl:text>&#160;</xsl:text>
																</span>
																<xsl:apply-templates/>
															</xsl:for-each>
														</xsl:for-each>
													</xsl:for-each>
													<xsl:for-each select="common:Person">
														<xsl:for-each select="common:Names">
															<xsl:for-each select="common:FamilyName">
																<span>
																	<xsl:text>&#160;</xsl:text>
																</span>
																<xsl:apply-templates/>
															</xsl:for-each>
														</xsl:for-each>
													</xsl:for-each>
													<xsl:for-each select="common:Person">
														<xsl:for-each select="common:EGN">
															<span>
																<xsl:text>, ЕГН: </xsl:text>
															</span>
															<xsl:apply-templates/>
														</xsl:for-each>
													</xsl:for-each>
												</xsl:when>
											</xsl:choose>
											<br/>
										</li>
									</ul>
									<br/>
								</xsl:for-each>
								<br/>
							</xsl:for-each>
						</xsl:for-each>
						<br/>
						<span>
							<xsl:text>III. Основни характеристики на кораба</xsl:text>
						</span>
						<xsl:for-each select="n1:VesselInfo">
							<xsl:for-each select="common:MainFeatures">
								<br/>
								<ul start="0" type="disc">
									<li>
										<span>
											<xsl:text>Брутотон: </xsl:text>
										</span>
										<xsl:for-each select="common:BT">
											<xsl:apply-templates/>
										</xsl:for-each>
									</li>
									<li>
										<span>
											<xsl:text>Нетотон: </xsl:text>
										</span>
										<xsl:for-each select="common:NT">
											<xsl:apply-templates/>
										</xsl:for-each>
									</li>
									<li>
										<span>
											<xsl:text>Дължина, максимална: </xsl:text>
										</span>
										<xsl:for-each select="common:MaxLength">
											<xsl:apply-templates/>
										</xsl:for-each>
									</li>
									<li>
										<span>
											<xsl:text>Ширина, максимална: </xsl:text>
										</span>
										<xsl:for-each select="common:MaxWidth">
											<xsl:apply-templates/>
										</xsl:for-each>
									</li>
									<li>
										<span>
											<xsl:text>Газене: </xsl:text>
										</span>
										<xsl:for-each select="common:Waterplane">
											<xsl:apply-templates/>
										</xsl:for-each>
									</li>
									<li>
										<span>
											<xsl:text>Височина на борда: </xsl:text>
										</span>
										<xsl:for-each select="common:ShipboardHeight">
											<xsl:apply-templates/>
										</xsl:for-each>
									</li>
									<li>
										<span>
											<xsl:text>Дедуейт: </xsl:text>
										</span>
										<xsl:for-each select="common:Deadweight">
											<xsl:apply-templates/>
										</xsl:for-each>
									</li>
									<li>
										<span>
											<xsl:text>Брой на главните двигатели: </xsl:text>
										</span>
										<xsl:for-each select="common:NumberOfEngines">
											<xsl:apply-templates/>
										</xsl:for-each>
									</li>
									<li>
										<span>
											<xsl:text>Обща номинална мощност: </xsl:text>
										</span>
										<xsl:for-each select="common:SumEnginePower">
											<xsl:apply-templates/>
										</xsl:for-each>
									</li>
									<li>
										<span>
											<xsl:text>Номер на корпус: </xsl:text>
										</span>
										<xsl:for-each select="common:BodyNumber">
											<xsl:apply-templates/>
										</xsl:for-each>
									</li>
									<li>
										<span>
											<xsl:text>Двигатели: </xsl:text>
										</span>
									</li>
								</ul>
								<xsl:for-each select="common:Engines">
									<br/>
									<xsl:for-each select="common:Engine">
										<br/>
										<ul start="0">
											<li type="circle">
												<xsl:for-each select="common:SystemModification">
													<span>
														<xsl:text>Система/Модификация: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="common:EngineNumber">
													<br/>
													<span>
														<xsl:text>Номер на двигател: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="common:Power">
													<br/>
													<span>
														<xsl:text>Ефективна мощност: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="common:Type">
													<br/>
													<span>
														<xsl:text>Вид на двигателя: </xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
											</li>
										</ul>
									</xsl:for-each>
								</xsl:for-each>
								<br/>
							</xsl:for-each>
						</xsl:for-each>
					</xsl:for-each>
					<br/>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
